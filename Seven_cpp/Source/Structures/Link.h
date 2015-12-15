// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Structures_Array_h
#define Structures_Array_h

#include <string>
#include "..\Seven.h"
#include <tuple>

namespace Seven
{
	namespace Structures
	{
		template<typename ... T>
		class Link;

		/// <summary>Contiguous fixed-sized data structure.</summary>
		template <typename T, typename .. T2>
		struct Link : Structure<T...>
		{

			int Size() = 0;

			std::tuple<int, int> tuple;
		};

		/// <summary>Contiguous fixed-sized data structure.</summary>
		template<typename ... T>
		struct Link : public Link<T ...>
		{
			
		};

		#pragma region tuple

		// STRUCT allocator_arg_t
		struct allocator_arg_t
		{	// tag type for added allocator argument
		};

		// CLASS tuple
		template<class... _Types>
		class tuple;

		template<>
		class tuple<>
		{	// empty tuple
		public:
			typedef tuple<> _Myt;

			tuple()
			{	// default construct
			}

			template<class _Alloc>
			tuple(allocator_arg_t, const _Alloc&) _NOEXCEPT
			{	// default construct, allocator
			}

			tuple(const tuple&) _NOEXCEPT
			{	// copy construct
			}

			template<class _Alloc>
			tuple(allocator_arg_t, const _Alloc&, const tuple&) _NOEXCEPT
			{	// copy construct, allocator
			}

			void swap(_Myt&) _NOEXCEPT
			{	// swap elements
			}

			bool _Equals(const _Myt&) const _NOEXCEPT
			{	// test if *this == _Right
				return (true);
			}

				bool _Less(const _Myt&) const _NOEXCEPT
			{	// test if *this < _Right
				return (false);
			}
		};

		template<class _This, class... _Rest>
		class tuple<_This, _Rest...> :
			private tuple<_Rest...>
		{	// recursive tuple definition
		public:
			typedef _This _This_type;
			typedef tuple<_This, _Rest...> _Myt;
			typedef tuple<_Rest...> _Mybase;
			static const size_t _Mysize = 1 + sizeof...(_Rest);

			tuple()
				: _Mybase(),
				_Myfirst()
			{	// construct default
			}

			template<class... _Rest2>
			explicit tuple(_Tuple_alloc_t, _Rest2&&... _Rest_arg)
				: _Mybase(_STD forward<_Rest2>(_Rest_arg)...),
				_Myfirst(allocator_arg)
			{	// construct smuggled allocator_arg_t element
			}

			template<class... _Other,
			class = typename _Tuple_enable<
				tuple<const _Other&...>, _Myt>::type>
				tuple(const tuple<_Other...>& _Right)
				: _Mybase(_Right._Get_rest()), _Myfirst(_Right._Myfirst._Val)
			{	// construct by copying same size tuple
			}

			template<class _Alloc,
			class... _Other,
			class = typename _Tuple_enable<
				tuple<const _Other&...>, _Myt>::type>
				tuple(allocator_arg_t, const _Alloc& _Al,
				const tuple<_Other...>& _Right)
				: _Mybase(allocator_arg, _Al, _Right._Get_rest()),
				_Myfirst(_Al, _Tuple_alloc,
				_Right._Myfirst._Val)
			{	// construct by copying same size tuple, allocator
			}

			explicit tuple(const _This& _This_arg, const _Rest&... _Rest_arg)
				: _Mybase(_Rest_arg...),
				_Myfirst(_This_arg)
			{	// construct from one or more copied elements
			}

			template<class _Alloc>
			tuple(allocator_arg_t, const _Alloc& _Al,
				const _This& _This_arg, const _Rest&... _Rest_arg)
				: _Mybase(allocator_arg, _Al, _Rest_arg...),
				_Myfirst(_Al, _Tuple_alloc, _This_arg)
			{	// construct from one or more copied elements, allocator
			}

			template<class _This2,
			class... _Rest2,
			class = typename _Tuple_enable<
				tuple<_This2, _Rest2...>, _Myt>::type>
				explicit tuple(_This2&& _This_arg, _Rest2&&... _Rest_arg)
				: _Mybase(_STD forward<_Rest2>(_Rest_arg)...),
				_Myfirst(_STD forward<_This2>(_This_arg))
			{	// construct from one or more moved elements
			}

			template<class _Alloc,
			class _This2,
			class... _Rest2,
			class = typename _Tuple_enable<
				tuple<_This2, _Rest2...>, _Myt>::type>
				tuple(allocator_arg_t, const _Alloc& _Al,
				_This2&& _This_arg, _Rest2&&... _Rest_arg)
				: _Mybase(allocator_arg, _Al,
				_STD forward<_Rest2>(_Rest_arg)...),
				_Myfirst(_Al, _Tuple_alloc,
				_STD forward<_This2>(_This_arg))
			{	// construct from one or more moved elements, allocator
			}

			template<class... _Other,
			class = typename _Tuple_enable<
				tuple<_Other...>, _Myt>::type>
				tuple(tuple<_Other...>&& _Right)
				: _Mybase(_STD forward<typename tuple<_Other...>::_Mybase>
				(_Right._Get_rest())),
				_Myfirst(_STD forward<typename tuple<_Other...>::_This_type>
				(_Right._Myfirst._Val))
			{	// construct by moving same size tuple
			}

			template<class _Alloc,
			class... _Other,
			class = typename _Tuple_enable<
				tuple<_Other...>, _Myt>::type>
				tuple(allocator_arg_t, const _Alloc& _Al,
				tuple<_Other...>&& _Right)
				: _Mybase(allocator_arg, _Al,
				_STD forward<typename tuple<_Other...>::_Mybase>
				(_Right._Get_rest())),
				_Myfirst(_Al, _Tuple_alloc,
				_STD forward<typename tuple<_Other...>::_This_type>
				(_Right._Myfirst._Val))
			{	// construct by moving same size tuple, allocator
			}

			template<class... _Other>
			_Myt& operator=(const tuple<_Other...>& _Right)
			{	// assign by copying same size tuple
				_Myfirst._Val = _Right._Myfirst._Val;
				(_Mybase&)*this = _Right._Get_rest();
				return (*this);
			}

			template<class... _Other>
			_Myt& operator=(tuple<_Other...>&& _Right)
			{	// assign by moving same size tuple
				_Myfirst._Val = _STD forward<typename tuple<_Other...>::_This_type>
					(_Right._Myfirst._Val);
				(_Mybase&)*this = _STD forward<typename tuple<_Other...>::_Mybase>
					(_Right._Get_rest());
				return (*this);
			}

			template<class... _Other>
			bool _Equals(const tuple<_Other...>& _Right) const
			{	// test if *this == _Right
				static_assert(_Mysize == sizeof...(_Other),
					"comparing tuple to object with different size");
				return (_Myfirst._Val == _Right._Myfirst._Val
					&& _Mybase::_Equals(_Right._Get_rest()));
			}

			template<class... _Other>
			bool _Less(const tuple<_Other...>& _Right) const
			{	// test if *this < _Right
				static_assert(_Mysize == sizeof...(_Other),
					"comparing tuple to object with different size");
				return (_Myfirst._Val < _Right._Myfirst._Val
					|| (!(_Right._Myfirst._Val < _Myfirst._Val)
					&& _Mybase::_Less(_Right._Get_rest())));
			}

			template<class _Alloc>
			tuple(allocator_arg_t, const _Alloc& _Al)
				: _Mybase(allocator_arg, _Al),
				_Myfirst(_Al, _Tuple_alloc)
			{	// construct default, allocator
			}

			template<class _Alloc>
			tuple(allocator_arg_t, const _Alloc& _Al,
				const _Myt& _Right)
				: _Mybase(allocator_arg, _Al, _Right._Get_rest()),
				_Myfirst(_Al, _Tuple_alloc,
				_Right._Myfirst._Val)
			{	// construct by copying, allocator
			}

			template<class _First,
			class _Second,
			class = typename _Tuple_enable<
				tuple<const _First&, const _Second&>, _Myt>::type>
				tuple(const pair<_First, _Second>& _Right)

				: _Mybase(tuple<_Second>(_Right.second)),
				_Myfirst(_Right.first)
			{	// construct by copying pair
				// no static_assert necessary
			}

			template<class _Alloc,
			class _First,
			class _Second,
			class = typename _Tuple_enable<
				tuple<const _First&, const _Second&>, _Myt>::type>
				tuple(allocator_arg_t, const _Alloc& _Al,
				const pair<_First, _Second>& _Right)

				: _Mybase(allocator_arg, _Al, tuple<_Second>(_Right.second)),
				_Myfirst(_Al, _Tuple_alloc,
				_Right.first)
			{	// construct by copying pair, allocator
				// no static_assert necessary
			}

			_Myt& operator=(const _Myt& _Right)
			{	// assign
				_Myfirst._Val = _Right._Myfirst._Val;
				(_Mybase&)*this = _Right._Get_rest();
				return (*this);
			}

			template<class _First,
			class _Second>
				_Myt& operator=(const pair<_First, _Second>& _Right)
			{	// assign by copying pair
				static_assert(_Mysize == 2,
					"assigning to tuple from object with different size");
				_Myfirst._Val = _Right.first;
				(_Mybase&)*this = tuple<_Second>(_Right.second);
				return (*this);
			}

			template<class _Alloc>
			tuple(allocator_arg_t, const _Alloc& _Al,
				_Myt&& _Right)
				: _Mybase(allocator_arg, _Al,
				_STD forward<_Mybase>(_Right._Get_rest())),
				_Myfirst(_Al, _Tuple_alloc,
				_STD forward<_This>(_Right._Myfirst._Val))
			{	// construct by moving, allocator
			}

			template<class _First,
			class _Second,
			class = typename _Tuple_enable<
				tuple<_First, _Second>, _Myt>::type>
				tuple(pair<_First, _Second>&& _Right)

				: _Mybase(tuple<_Second>(_STD forward<_Second>(_Right.second))),
				_Myfirst(_STD forward<_First>(_Right.first))
			{	// construct by moving pair
				// no static_assert necessary
			}

			template<class _Alloc,
			class _First,
			class _Second,
			class = typename _Tuple_enable<
				tuple<_First, _Second>, _Myt>::type>
				tuple(allocator_arg_t, const _Alloc& _Al,
				pair<_First, _Second>&& _Right)

				: _Mybase(allocator_arg, _Al,
				tuple<_Second>(_STD forward<_Second>(_Right.second))),
				_Myfirst(_Al, _Tuple_alloc,
				_STD forward<_First>(_Right.first))
			{	// construct by moving pair, allocator
				// no static_assert necessary
			}

			_Myt& operator=(_Myt&& _Right)
				_NOEXCEPT_OP(is_nothrow_move_assignable<_This>::value
				&& is_nothrow_move_assignable<_Mybase>::value)
			{	// assign by moving
				_Myfirst = _STD forward<_This>(_Right._Myfirst._Val);
				(_Mybase&)*this = _STD forward<_Mybase>(_Right._Get_rest());
				return (*this);
			}

			template<class _First,
			class _Second>
				_Myt& operator=(pair<_First, _Second>&& _Right)
				_NOEXCEPT_OP(
				_NOEXCEPT_OP(_Myfirst._Val = _STD forward<_First>(_Right.first))
				&& _NOEXCEPT_OP((_Mybase&)*this =
				tuple<_Second>(_STD forward<_Second>(_Right.second))))
			{	// assign by moving pair
				static_assert(_Mysize == 2,
					"assigning to tuple from object with different size");
				_Myfirst._Val = _STD forward<_First>(_Right.first);
				(_Mybase&)*this =
					tuple<_Second>(_STD forward<_Second>(_Right.second));
				return (*this);
			}

			_Mybase& _Get_rest()
			{	// get reference to rest of elements
				return (*this);
			}

			const _Mybase& _Get_rest() const
			{	// get const reference to rest of elements
				return (*this);
			}

			void swap(tuple& _Right)
				_NOEXCEPT_OP(
				_NOEXCEPT_OP(_Swap_adl(_Myfirst._Val, _Myfirst._Val))
				&& _NOEXCEPT_OP(_Swap_adl((_Mybase&)_Right, (_Mybase&)_Right)))
			{	// swap *this and _Right
				_Swap_adl(_Myfirst._Val, _Right._Myfirst._Val);
				_Mybase::swap((_Mybase&)_Right);
			}

			_Tuple_val<_This> _Myfirst;	// the stored element
		};

		#pragma endregion
	}
}

#endif